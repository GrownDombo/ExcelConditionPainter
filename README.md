# ExcelConditionPainter

ExcelConditionPainter는 Excel 주문 데이터를 조건별로 검색하고, 결과를 색상으로 표시한 뒤 파일로 내보내는 Windows Forms 기반 데스크톱 도구입니다.

반복적인 Excel 검수 작업에서 조건에 맞는 주문자, 중복값, 수량 기준, 특정 옵션 구매자를 빠르게 찾고 시각적으로 구분하기 위해 만들었습니다.
조건 계산, Excel 처리, 화면 색칠 책임을 분리해 새로운 조건을 추가하거나 Export 방식을 조정하기 쉽도록 구성했습니다.

## 핵심 기능

- Excel 파일 로드 및 `DataGridView` 기반 미리보기
- 조건별 검색 및 색상 표시
  - 중복 제외 순차 검색
  - 중복값 Cell 검색
  - 총 구매 수량 검색
  - 특정 옵션 구매 검색
- 다중 컬럼 선택 시 조건별 `AND` / `OR` 검색 지원
  - 컬럼 조건은 사용자가 선택 가능
  - `OR` 검색은 컬럼별 결과를 합산하고 중복 primary key를 제거
  - 중복값 Cell 검색은 실제 중복된 셀만 색상 표시
  - 특정 옵션 구매 조건은 `OR` 고정
- 옵션 화면에서 조건별 기본 검색 방식 설정
- 조건 우선순위, Font / Fill 색상, 삭제 및 추가 UI 제공
- 조건 목록 스크롤과 선택 상태에서도 조건 색상이 유지되는 그리드 UI
- 조건 결과 Export
  - 전체 결과 `_Default` 파일 저장
  - 옵션에 따라 조건별 분리 파일 저장
- `Ctrl + F` 검색 및 결과 위치 이동

## 기술 스택

- C#
- .NET Framework 4.8
- Windows Forms
- ClosedXML
- WinFormsCustomControls `FileVersion 1.0.0.2`
- Visual Studio Setup Project

## 프로젝트 구조

```text
ExcelConditionPainter/
├─ Class/
│  ├─ ConditionEvaluationContext.cs
│  ├─ ConditionGroupCalculation.cs
│  ├─ ConditionPaintInstruction.cs
│  └─ ConditionRules.cs
├─ ClassStatic/
│  └─ AppOptions.cs
├─ Interface/
│  └─ Conditions.cs
├─ Services/
│  ├─ ConditionEvaluationService.cs
│  ├─ ExcelWorkbookService.cs
│  └─ GridPainter.cs
└─ UI/
   ├─ FormSetConditions.cs
   ├─ FormOptions.cs
   ├─ FormSearch.cs
   └─ Conditions/
      ├─ ConditionControlFactory.cs
      └─ *ConditionControl.cs
```

## 빌드

Visual Studio 2022에서 솔루션을 열고 `ExcelConditionPainter` 프로젝트를 빌드합니다.

명령줄 빌드:

```powershell
& 'C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe' ExcelConditionPainter\ExcelConditionPainter\ExcelConditionPainter.csproj /p:Configuration=Release /v:minimal
```

## 실행 흐름

1. `Open`으로 Excel 파일을 선택합니다.
2. 조건 설정 창에서 기준 컬럼과 검색 조건을 설정합니다.
3. 조건별 색상과 우선순위를 지정합니다.
4. 결과를 그리드에서 확인합니다.
5. `Export`로 결과 파일을 저장합니다.

## 샘플 데이터

기능 확인용 샘플 파일:

```text
DummyData_400Rows_Shuffled.xlsx
```

## 라이선스

프로젝트 라이선스는 `LICENSE`를 참고하세요.

ClosedXML 등 서드파티 라이브러리 고지는 아래 파일에서 확인할 수 있습니다.

```text
ExcelConditionPainter/ExcelConditionPainter/Installers/ThirdPartyLicenses/THIRD-PARTY-NOTICES.txt
```
