Feature: Login
	Iniciar Sesión en la aplicación web de PosiPrice

@smoke
Scenario: As a User i want to login to PosiPrice Web Application
	#steps
	Given  I enter to the loginpage
	When I enter my username <username> and password <password>
	And I click the login  button
	Then I should enter to the home page

Examples: 
	| Username         | Passoword   |
	| gianlucalapadula | password    |
	| cristhiancueva   | secret      |
	| ricardogareca    | dtseleccion |