Feature: Login to at and capture error message for failure

  Scenario Outline: Login to at and capture error message for failure
    Given I'm on login screen of at using <browser>
    When I enter username <user>, password <pass> and submit
    Then If i get error message, capture it.
    Examples:
      |browser            | user              | pass       |
      |chrome             |sreerjvs@gmail     | sreerjvs85 |
      |chrome             |sree21@yahoo       | sree2119   |
      |chrome             |sreerjvs@gmail.com | R@vijaya7  |