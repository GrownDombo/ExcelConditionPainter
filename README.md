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
- GitHub Release 기반 설치 파일 배포

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

Setup 프로젝트는 Visual Studio Installer Projects 확장이 필요합니다. `main` 브랜치에 push되면 GitHub Actions가 `AssemblyInfo.cs`의 4자리 버전을 읽고, 같은 버전의 GitHub Release가 없을 때만 설치 파일을 빌드해 배포합니다.

배포 버전은 `ExcelConditionPainter/ExcelConditionPainter/Properties/AssemblyInfo.cs`의 `AssemblyVersion`과 `AssemblyFileVersion`을 기준으로 합니다. 두 값은 같은 4자리 버전이어야 하며, Release 태그는 `v1.0.1.0`처럼 생성됩니다.

마지막 자리만 올리는 경우에는 `AssemblyInfo.cs`만 수정하면 됩니다. 앞 3자리를 변경하는 경우에는 MSI의 `ProductVersion`도 같은 3자리 버전으로 맞춰야 하므로 `ExcelConditionPainter.Setup.vdproj`도 함께 수정합니다.

Release에는 아래 파일이 첨부됩니다.

- `ExcelConditionPainter.Setup.msi`: 프로그램을 설치하는 Windows Installer 패키지입니다.
- `setup.exe`: MSI 실행 전 필요한 구성 요소를 확인하고 설치를 시작하는 부트스트래퍼입니다.
- `SHA256SUMS.txt`: 배포 파일의 SHA256 체크섬입니다. 다운로드한 설치 파일이 배포 시점과 같은 파일인지 확인할 때 사용합니다.

## 사용 방법

자세한 사용 방법은 아래 페이지에서 확인할 수 있습니다.

https://growndombo.github.io/projects/excel-condition-painter

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
