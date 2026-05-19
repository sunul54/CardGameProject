# Cartifact 개발 프로젝트

턴제 카드 전투 게임 프로젝트.

Unity 6 기반으로 제작 중이며,
유지보수 가능한 구조와
데이터 중심 설계를 목표로 개발하고 있습니다.

---

# 게임 소개

플레이어는 카드를 사용하여
적과 턴제 전투를 진행합니다.

각 카드는 고유 효과를 가지며,
전략적인 선택을 통해 전투를 진행합니다.

---

# 핵심 시스템

- 턴제 전투 시스템
- 카드 기반 전투
- ScriptableObject 기반 데이터 관리
- 상태 기반 전투 흐름
- 이벤트 기반 구조
- 확장 가능한 AI 구조

---

# 기술 스택

- Unity 6
- C#
- ScriptableObject
- Coroutine
- FSM(State Machine)
- Git

---

# 프로젝트 구조

Assets
├── Scripts
│   ├── Battle
│   ├── Card
│   ├── UI
│   ├── Enemy
│   └── Systems

---

# 전투 시스템 구조

BattleManager
├── Turn System
├── Enemy Turn
├── Player Turn
└── Battle State

BattleUnit
├── HP
├── Damage
└── Death

---

# 카드 시스템 구조

CardData (ScriptableObject)
├── 카드 이름
├── 카드 설명
├── 공격력
└── 카드 이미지

---

# 개발 목표

단순히 기능 구현이 아니라:

- 유지보수 가능한 구조
- 확장 가능한 시스템
- 데이터 중심 설계

를 목표로 개발 중입니다.

---


# 실행 방법

1. Unity 6 프로젝트 열기
2. Main Scene 실행
3. Play 버튼 클릭

---

# 개발 기록

프로젝트는 지속적으로 구조 개선 및 리팩토링 중입니다.