Feature: Login to at and capture error message for failure
  @ignore
  Scenario Outline: Login to at and capture error message for failure
    Given I'm on login screen of at using <browser>
    When I enter username <user>, password <pass> and submit
    Then If i get error message, capture it.
    Examples:
      |browser  | user              | pass       |
      |chrome   |sreerjvs@gmail.com | R@vijaya7  |
  
  Scenario Outline: Login to at in chrome browser with valid login credentials to check the transactions
    Given I'm on login screen of at using chrome
    When I enter username sreerjvs@gmail.com , password R@vijaya7 and submit
    Then I click on View Transactions button to see all my previous travels
    Then Verify the <transaction> details like tag on, tag off and hop balance
    Examples:
      | transaction |
      | first       |
      | second      |
      | third       |
      | fourth      |
      | fifth       |

  Scenario Outline: Login to at in chrome browser with valid login credentials to check the transactions on different pages
    Given I'm on login screen of at using chrome
    When I enter username sreerjvs@gmail.com, password R@vijaya7 and submit
    Then I click on View Transactions button to see all my previous travels
    Then Verify the <transaction> details like tag on, tag off and hop balance on <pages>
    Examples:
      | transaction | pages |
      | second      | page2 |
      | third       | page3 |