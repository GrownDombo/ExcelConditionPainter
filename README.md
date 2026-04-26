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
- 결과 파일 저장 (`_Painted.xlsx`)

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

### Run

1. 프로그램 실행 후 `Open` 버튼으로 Excel 파일을 선택합니다.
2. 조건 설정 UI에서 검색 조건과 색상 옵션을 지정합니다.
3. `Export` 버튼을 눌러 결과 파일을 저장합니다.

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
- Export 결과 파일명에는 `_Painted.xlsx`가 붙습니다.
- Excel 파일 구조에 따라 조건 설정이 달라질 수 있습니다.
- 실제 업무 데이터 적용 전 샘플 파일로 먼저 검증하는 것을 권장합니다.

---

## 라이선스 안내

이 프로젝트는 ClosedXML 및 관련 의존 패키지를 사용합니다.

서드파티 라이브러리의 라이선스 고지는 아래 파일에서 확인할 수 있습니다.

`ExcelConditionPainter/ExcelConditionPainter/Installers/ThirdPartyLicenses/THIRD-PARTY-NOTICES.txt`

설치 파일에는 해당 고지 파일이 포함되며, 설치 과정에서도 Third-Party Notices 화면을 통해 확인할 수 있습니다.

프로젝트 자체 라이선스는 `LICENSE` 파일을 참고해 주세요.
