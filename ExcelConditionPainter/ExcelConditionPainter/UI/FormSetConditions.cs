using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 사용자가 정렬/컬럼/조건 설정을 선택하고 조건 평가를 실행하는 창입니다.
    /// </summary>
    public partial class FormSetConditions : Form
    {
        // 조건 설정 대상 메인 그리드입니다.
        private readonly DataGridView dataGridView;
        // 조건 전략을 실행하는 평가 서비스입니다.
        private readonly ConditionEvaluationService conditionEvaluationService;
        // Excel에서 읽어온 전체 컬럼명 목록입니다.
        private readonly string[] columnNames;
        // 조건 제한값에 사용할 전체 행 수입니다.
        private readonly int rowCount;
        // 현재 옵션 컬럼에서 추출한 옵션명 목록입니다.
        private string[] optionNames;

        // 조건 설정 완료 후 메인 폼에 전달할 평가 결과입니다.
        public ConditionEvaluationContext ConditionContext { get; private set; }

        /// <summary>
        /// 그리드 데이터의 컬럼을 분석하고 조건 설정 UI 기본값을 준비합니다.
        /// </summary>
        public FormSetConditions(DataGridView dataGridView)
        {
            InitializeComponent();

            this.dataGridView = dataGridView;
            conditionEvaluationService = new ConditionEvaluationService();
            optionNames = new string[0];
            ConditionContext = null;

            // 조건 설정에 사용할 원본 테이블입니다.
            DataTable dataTable = dataGridView.DataSource as DataTable;
            // 기본키 후보로 사용할 수 있는 컬럼명 목록입니다.
            List<string> primaryKeyCandidates = new List<string>();

            // 현재 검사 중인 컬럼 인덱스입니다.
            int columnIndex = 0;
            // 날짜형 컬럼으로 추정한 인덱스입니다.
            int dateColumnIndex = -1;
            // 주문자명 컬럼으로 추정한 인덱스입니다.
            int nameColumnIndex = -1;
            // 상품 옵션 컬럼으로 추정한 인덱스입니다.
            int optionColumnIndex = -1;
            // 구매 수량 컬럼으로 추정한 인덱스입니다.
            int countColumnIndex = -1;

            columnNames = new string[dataTable.Columns.Count];
            rowCount = dataTable.Rows.Count;
            foreach (DataColumn column in dataTable.Columns)
            {
                // 현재 검사 중인 컬럼명입니다.
                string columnName = columnNames[columnIndex++] = column.ColumnName;
                primarySortColumnComboBox.Items.Add(columnName);
                secondarySortColumnComboBox.Items.Add(columnName);
                goodsOptionColumnComboBox.Items.Add(columnName);
                buyCountColumnComboBox.Items.Add(columnName);

                // 컬럼 내 중복 여부를 확인할 고유값 집합입니다.
                HashSet<string> uniqueValues = new HashSet<string>();
                // 컬럼에 빈 값이 있는지 여부입니다.
                bool hasNull = false;
                // 컬럼 전체가 날짜로 해석 가능한지 여부입니다.
                bool isDateColumn = true;

                foreach (DataRow row in dataTable.Rows)
                {
                    // 현재 행의 컬럼 값입니다.
                    string value = row[column].ToString();
                    if (string.IsNullOrEmpty(value))
                    {
                        hasNull = true;
                        isDateColumn = false;
                        break;
                    }

                    uniqueValues.Add(value);
                    if (DateTime.TryParse(value, out _) == false)
                        isDateColumn = false;
                }

                if (!hasNull && uniqueValues.Count == dataTable.Rows.Count)
                    primaryKeyCandidates.Add(columnName);

                if (optionColumnIndex == -1 && columnName.Contains("옵션"))
                    optionColumnIndex = columnIndex - 1;
                else if (countColumnIndex == -1 && columnName.Contains("수량"))
                    countColumnIndex = columnIndex - 1;
                else if (dateColumnIndex == -1 && isDateColumn)
                    dateColumnIndex = columnIndex - 1;
                else if (nameColumnIndex == -1 && columnName.Contains("주문자"))
                    nameColumnIndex = columnIndex - 1;
            }

            // 기본키 후보 컬럼 개수입니다.
            int candidateCount = primaryKeyCandidates.Count();
            if (candidateCount <= 0)
            {
                MessageBox.Show("데이터 잘못됨 엑셀 파일 확인 필요함 - 기본키 잘못됨");
                DialogResult = DialogResult.Abort;
                return;
            }

            for (int i = 0; i < candidateCount; i++)
                primaryKeyComboBox.Items.Add(primaryKeyCandidates[i]);

            primaryKeyComboBox.SelectedIndex = 0;
            primarySortColumnComboBox.SelectedIndex = dateColumnIndex < 0 ? 0 : dateColumnIndex;
            secondarySortColumnComboBox.SelectedIndex = nameColumnIndex < 0 ? 0 : nameColumnIndex;
            goodsOptionColumnComboBox.SelectedIndex = optionColumnIndex < 0 ? 0 : optionColumnIndex;
            buyCountColumnComboBox.SelectedIndex = countColumnIndex < 0 ? 0 : countColumnIndex;

            foreach (ConditionRuleType conditionRuleType in Enum.GetValues(typeof(ConditionRuleType)))
                addConditionComboBox.Items.Add(conditionRuleType.GetDescription());

            addConditionComboBox.SelectedIndex = 0;

            foreach (Control control in conditionFlowPanel.Controls)
            {
                if (control is IConditionControl conditionControl)
                {
                    // 옵션 조건은 옵션명을, 나머지 조건은 컬럼명을 선택 항목으로 사용합니다.
                    string[] selectableItems = conditionControl is OptionPurchaseOrderConditionControl
                        ? optionNames
                        : columnNames;
                    conditionControl.SetSelectableItems(selectableItems, rowCount);
                }
            }
        }

        /// <summary>
        /// 상품 옵션 컬럼이 바뀌면 옵션별 수량 입력 컨트롤을 다시 만듭니다.
        /// </summary>
        private void goodsOptionColumnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 옵션명을 추출할 원본 테이블입니다.
                DataTable dataTable = dataGridView.DataSource as DataTable;
                optionQuantityFlowPanel.SuspendLayout();
                optionQuantityFlowPanel.Controls.Clear();

                // 중복 옵션명을 제거하기 위한 집합입니다.
                HashSet<string> uniqueValues = new HashSet<string>();
                // 사용자가 선택한 옵션 컬럼명입니다.
                string selectedColumn = goodsOptionColumnComboBox.SelectedItem.ToString();
                // 새로 추가할 옵션 수량 컨트롤 목록입니다.
                List<OptionQuantityControl> optionQuantityControls = new List<OptionQuantityControl>();
                foreach (DataRow row in dataTable.Rows)
                {
                    // 현재 행의 옵션 값입니다.
                    string value = row[selectedColumn].ToString();
                    if (string.IsNullOrEmpty(value) || uniqueValues.Contains(value))
                        continue;

                    uniqueValues.Add(value);
                    optionQuantityControls.Add(new OptionQuantityControl() { OptionName = value });
                }

                optionNames = uniqueValues.ToArray();
                optionQuantityFlowPanel.Controls.AddRange(optionQuantityControls.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                optionQuantityFlowPanel.ResumeLayout();
            }
        }

        /// <summary>
        /// 선택한 조건 타입의 조건 컨트롤을 추가합니다.
        /// </summary>
        private void addConditionButton_Click(object sender, EventArgs e)
        {
            conditionFlowPanel.SuspendLayout();
            try
            {
                // 새 조건에 부여할 다음 우선순위입니다.
                int nextPriorityLevel = conditionFlowPanel.Controls
                    .OfType<IConditionControl>()
                    .Select(c => c.PriorityLevel)
                    .DefaultIfEmpty(-1)
                    .Max() + 1;

                // 콤보박스에서 선택한 조건 타입입니다.
                ConditionRuleType selectedRuleType = (ConditionRuleType)addConditionComboBox.SelectedIndex;
                // Factory에서 생성한 조건 UI 컨트롤입니다.
                IConditionControl conditionControl = ConditionControlFactory.Create(selectedRuleType, columnNames, optionNames, rowCount);

                if (conditionControl == null)
                    return;

                conditionControl.PriorityLevel = nextPriorityLevel;
                conditionFlowPanel.Controls.Add(conditionControl as Control);
            }
            finally
            {
                conditionFlowPanel.ResumeLayout(false);
                conditionFlowPanel.PerformLayout();
            }
        }

        /// <summary>
        /// 현재 UI 설정값으로 조건을 평가하고 결과 컨텍스트를 생성합니다.
        /// </summary>
        private void setButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 1차 정렬 컬럼명입니다.
                string primarySortColumnName = primarySortColumnComboBox.SelectedItem.ToString();
                // 2차 정렬 컬럼명입니다.
                string secondarySortColumnName = secondarySortColumnComboBox.SelectedItem.ToString();
                // 정렬과 조건 평가에 사용할 테이블입니다.
                DataTable dataTable = dataGridView.DataSource as DataTable;
                dataTable.DefaultView.Sort = $"{primarySortColumnName} ASC, {secondarySortColumnName} ASC";
                dataTable = dataTable.DefaultView.ToTable();

                // 기본키로 사용할 컬럼명입니다.
                string primaryKey = primaryKeyComboBox.SelectedItem.ToString();
                // DataTable.PrimaryKey에 설정할 컬럼 객체입니다.
                DataColumn primaryKeyColumn = dataTable.Columns[primaryKey];
                dataTable.PrimaryKey = new DataColumn[] { primaryKeyColumn };

                // 구매 수량 컬럼명입니다.
                string buyCountColumnName = buyCountColumnComboBox.SelectedItem.ToString();
                // 상품 옵션 컬럼명입니다.
                string optionColumnName = goodsOptionColumnComboBox.SelectedItem.ToString();
                // 옵션명별 실제 상품 수량입니다.
                Dictionary<string, int> goodsQuantitiesByOption = new Dictionary<string, int>();
                foreach (Control control in optionQuantityFlowPanel.Controls)
                {
                    if (control is OptionQuantityControl optionQuantityControl)
                    {
                        if (string.IsNullOrEmpty(optionQuantityControl.OptionName))
                            continue;

                        goodsQuantitiesByOption.Add(optionQuantityControl.OptionName, optionQuantityControl.OptionCount);
                    }
                }

                // UI 컨트롤에서 만들어낸 순수 조건 전략 목록입니다.
                List<IConditionRule> conditionRules = conditionFlowPanel.Controls
                    .OfType<IConditionControl>()
                    .Select(control => control.CreateRule())
                    .ToList();

                // 평가는 서비스에 위임하고, 이 폼은 UI 입력 수집만 담당합니다.
                ConditionContext = conditionEvaluationService.Evaluate(primaryKey, buyCountColumnName, optionColumnName, goodsQuantitiesByOption, dataTable, conditionRules);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
