# ExcelConditionPainter

사용자 정의 조건에 따라 Excel 데이터를 강조 표시하고, 결과를 새 파일로 내보낼 수 있는 Windows Forms 기반 데스크톱 도구입니다.

> **프로젝트를 만든 이유**  
> Excel 데이터 정리 과정에서 특정 조건에 해당하는 항목을 빠르게 찾고 시각적으로 구분할 필요가 있었습니다.  
> 단순 필터링만으로는 부족해, 조건별 색상 표시와 결과 내보내기를 지원하는 도구 형태로 구현했습니다.

---

## 프로젝트 소개

Excel 파일을 불러온 뒤, 사용자가 지정한 조건에 따라 데이터를 검색하고 강조 표시할 수 있습니다.

주요 목적은 다음과 같습니다.

- 조건 기반 Excel 데이터 강조 표시
- 중복값, 수량, 옵션 등 기준 검색
- AND / OR 조건 조합 지원
- 조건 우선순위 설정
- 강조 색상 지정
- 결과 파일 Export

---

## 주요 기능

- Excel 파일 불러오기
- 조건별 검색 및 강조 표시
- 기본키 / 정렬 기준 / 수량 / 옵션 컬럼 설정
- AND / OR 조건 조합
- 조건 우선순위(Lv) 설정
- Font / Fill 색상 지정
- `Ctrl + F` 검색 기능
- 결과 파일 저장 (`_Default` 파일 및 조건별 분리 파일)

---

## 사용 흐름

1. `Open` 버튼으로 Excel 파일을 불러옵니다.
2. 조건 설정 UI에서 검색 조건을 추가합니다.
3. 필요 시 색상 옵션과 우선순위를 설정합니다.
4. 검색 기능으로 데이터를 확인합니다.
5. `Export` 버튼으로 결과 파일을 저장합니다.

---

## 기술 스택

- **Language**: C#
- **Framework**: .NET Framework 4.8
- **UI**: Windows Forms
- **Excel Handling**: ClosedXML
- **Installer**: Visual Studio Setup Project

---

## 구조와 적용 패턴

최근 리팩토링을 통해 WinForms 이벤트 코드에 몰려 있던 책임을 서비스와 조건 전략으로 분리했습니다.

- **Service Layer**
  - `ExcelWorkbookService`: Excel 파일 읽기, 기본 Export, 조건별 분리 Export를 담당합니다.
  - `ConditionEvaluationService`: 조건 Rule 목록을 우선순위대로 평가하고 결과 컨텍스트를 생성합니다.
  - `GridPainter`: 조건 평가 결과를 `DataGridView`의 행/셀 색상으로 반영합니다.
- **Strategy Pattern**
  - `IConditionRule` 기반으로 중복, 수량, 옵션 구매 순서 등 조건별 계산 로직을 분리했습니다.
  - WinForms 컨트롤은 UI 입력을 수집하고, 실제 계산은 Rule 객체가 수행합니다.
- **Factory Pattern**
  - `ConditionControlFactory`가 조건 타입에 맞는 조건 UI 컨트롤을 생성합니다.
- **DTO / Settings Object**
  - `ConditionPaintInstruction`이 조건 색칠 대상, 색상, 적용 순번 정보를 전달합니다.
- **Adapter / Facade**
  - ClosedXML 사용 세부사항은 `ExcelWorkbookService` 내부로 숨겨 Form 코드가 직접 알지 않도록 했습니다.

---

## 주요 코드 구조

```text
ExcelConditionPainter/
├─ Class/
│  ├─ ConditionEvaluationContext.cs      # 조건 평가 중 공유하는 입력 데이터, 캐시, 적용 결과 저장소
│  ├─ ConditionGroupCalculation.cs       # 그룹별 첫 행 기본키, 추가 기본키, 누적 수량 계산 모델
│  ├─ ConditionPaintInstruction.cs       # GridPainter가 사용할 색칠 대상/색상/순번 정보 객체
│  └─ ConditionRules.cs                  # 중복, 수량, 옵션 구매 순서 등 실제 조건 계산 전략
├─ Interface/
│  └─ Conditions.cs                      # 조건 타입 enum, 색칠 설정, UI 컨트롤/Rule 인터페이스
├─ Services/
│  ├─ ConditionEvaluationService.cs      # 조건 Rule 목록을 우선순위대로 실행하고 평가 결과 생성
│  ├─ ExcelWorkbookService.cs            # Excel 파일 읽기, 기본 Export, 조건별 분리 Export 처리
│  ├─ ExcelExportResult.cs               # Export 후 생성 파일과 열 대상 경로를 담는 결과 객체
│  └─ GridPainter.cs                     # 조건 평가 결과를 DataGridView 행/셀 스타일로 반영
└─ UI/
   ├─ FormSetConditions.cs               # 기본키, 정렬, 옵션 수량, 조건 목록을 설정하는 창
   ├─ FormSearch.cs                      # Ctrl+F 검색과 검색 결과 위치 이동 창
   ├─ FormOptions.cs                     # Export 옵션을 설정하고 저장하는 창
   └─ Conditions/
      ├─ ConditionControlFactory.cs      # 조건 타입에 맞는 조건 UI 컨트롤 생성
      └─ *ConditionControl.cs            # 조건별 UI 입력을 수집하고 계산 Rule 생성
```

---

## 개발 환경

- Visual Studio 2022
- .NET Framework 4.8
- Visual Studio Installer Projects 확장
- NuGet 패키지 복원 필요

---

## 실행 방법

### Build

1. Visual Studio에서 솔루션을 엽니다.
2. 빌드 구성을 `Debug` 또는 `Release`로 선택합니다.
3. NuGet 패키지를 복원합니다.
4. `ExcelConditionPainter` 프로젝트를 빌드합니다.
5. 빌드된 실행 파일을 실행합니다.

명령줄 빌드 예시는 다음과 같습니다.

```powershell
& 'C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe' ExcelConditionPainter\ExcelConditionPainter\ExcelConditionPainter.csproj /p:Configuration=Release /v:minimal
```

### Run

1. 프로그램 실행 후 `Open` 버튼으로 Excel 파일을 선택합니다.
2. 조건 설정 UI에서 검색 조건과 색상 옵션을 지정합니다.
3. `Export` 버튼을 눌러 결과 파일을 저장합니다.

---

## 상세 사용법

화면별 설정 방법과 예시를 포함한 상세 사용법은 아래 글에서 확인할 수 있습니다.

[Excel 조건부 표시 프로그램 사용법](https://growndombo.tistory.com/entry/Excel-%EC%A1%B0%EA%B1%B4%EB%B6%80-%ED%91%9C%EC%8B%9C-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%A8-%EC%82%AC%EC%9A%A9%EB%B2%95)

---

## 설치 파일 빌드

설치 파일은 `ExcelConditionPainter.Setup` 프로젝트를 통해 생성합니다.

1. Visual Studio에서 솔루션을 엽니다.
2. `Release` 구성을 선택합니다.
3. `ExcelConditionPainter.Setup` 프로젝트를 빌드합니다.
4. 빌드가 완료되면 설치 파일이 생성됩니다.

설치 후 다음 항목이 생성됩니다.

- 프로그램 설치 폴더
- 바탕화면 바로가기
- 시작 메뉴 바로가기
- `THIRD-PARTY-NOTICES.txt` 라이선스 고지 파일

---

## 샘플 데이터

테스트용 더미 데이터로 기능을 빠르게 확인할 수 있습니다.

- `DummyData_400Rows_Shuffled.xlsx`

실제 업무 데이터에 적용하기 전, 샘플 파일로 먼저 기능을 확인하는 것을 권장합니다.

---

## 참고 사항

- 결과 파일은 원본 파일을 덮어쓰지 않고 새 파일로 저장됩니다.
- 기본 Export 결과 파일명에는 `_Default`가 붙습니다.
- 조건별 분리 Export를 켜면 `ExcelPainter` 폴더 안에 조건 적용 순번별 파일이 추가로 생성됩니다.
- Excel 파일 구조에 따라 조건 설정이 달라질 수 있습니다.
- 실제 업무 데이터 적용 전 샘플 파일로 먼저 검증하는 것을 권장합니다.

---

## 라이선스 안내

이 프로젝트는 ClosedXML 및 관련 의존 패키지를 사용합니다.

서드파티 라이브러리의 라이선스 고지는 아래 파일에서 확인할 수 있습니다.

`ExcelConditionPainter/ExcelConditionPainter/Installers/ThirdPartyLicenses/THIRD-PARTY-NOTICES.txt`

설치 파일에는 해당 고지 파일이 포함되며, 설치 과정에서도 Third-Party Notices 화면을 통해 확인할 수 있습니다.

프로젝트 자체 라이선스는 `LICENSE` 파일을 참고해 주세요.
