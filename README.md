# Применение закона Ома — Вариант №3

Учебная работа по дисциплине «Разработка и тестирование программного обеспечения».  
WPF-приложение для вычисления величин по закону Ома с модульными тестами и тестовой документацией.

---

## Состав репозитория

```
/
├── WpfAppTK/
│   ├── OhmCalculator.cs       # Бизнес-логика (вычисления)
│   ├── MainWindow.xaml        # Разметка главного окна
│   └── MainWindow.xaml.cs     # Код главного окна
├── UnitTestProject/
│   └── OhmCalculatorTests.cs  # Модульные тесты (MSTest)
├── Тестовые сценарии.docx        # Тестовые сценарии по шаблону
└── README.md
```

---

## Описание приложения

Приложение реализует вычисление трёх величин закона Ома:

| Режим | Формула |
|---|---|
| Сила тока | I = V / R |
| Напряжение | V = I × R |
| Сопротивление | R = V / I |

Пользователь выбирает вычисляемую величину через переключатель — подписи полей ввода меняются автоматически. При некорректном вводе или делении на ноль отображается сообщение об ошибке.

**Стек:** C# 7.3 · .NET Framework 4.8 · WPF

### Скриншот приложения

<img width="500" alt="image" src="https://github.com/user-attachments/assets/5ce97e78-d4f9-41f5-9f2d-d5a4aba783a4" />

<img width="500" alt="image" src="https://github.com/user-attachments/assets/02658575-9861-4162-8687-d46a3fa7f57c" />

<img width="500"  alt="image" src="https://github.com/user-attachments/assets/0fd150e9-5ed3-4bd7-a903-d80fd0d89257" />

---

## Архитектура

Бизнес-логика вынесена в отдельный класс `OhmCalculator`, независимый от UI — это позволяет тестировать вычисления без запуска приложения.

```
MainWindow  ->  OhmCalculator
  (UI)              (логика)
                CalculateCurrent(v, r)
                CalculateVoltage(i, r)
                CalculateResistance(v, i)
                Calculate(type, p1, p2)
```

---

## Модульные тесты

Тесты написаны с использованием **MSTest** (.NET Framework 4.8).  
Покрывают: корректные вычисления, граничные случаи (ноль), отрицательные значения, исключения.

| # | Метод теста | Ожидаемый результат |
|---|---|---|
| 1 | `CalculateCurrent_ValidValues` | I = 12/4 = 3 |
| 2 | `CalculateVoltage_ValidValues` | V = 3×4 = 12 |
| 3 | `CalculateResistance_ValidValues` | R = 12/3 = 4 |
| 4 | `CalculateCurrent_ZeroVoltage` | I = 0 |
| 5 | `CalculateVoltage_ZeroCurrent` | V = 0 |
| 6 | `CalculateResistance_ZeroVoltage` | R = 0 |
| 7 | `CalculateCurrent_NegativeVoltage` | I = -10/2 = -5 |
| 8 | `CalculateCurrent_ZeroResistance` | `DivideByZeroException` |
| 9 | `CalculateResistance_ZeroCurrent` | `DivideByZeroException` |
| 10 | `Calculate_InvalidType` | `ArgumentOutOfRangeException` |

### Скриншоты результатов тестирования

<img width="1807" height="702" alt="image" src="https://github.com/user-attachments/assets/f6c04655-30cd-4848-9616-e27da64e0e47" />

---

## Тестовые сценарии

Ручные тестовые сценарии оформлены в файле `Тестовые сценарии.docx` по стандартному шаблону.  
Документ содержит 10 тест-кейсов (TC_FUNC_1–7, TC_ERR_1–3) с полями: приоритет, шаги, данные, ожидаемый и фактический результат, статус.

