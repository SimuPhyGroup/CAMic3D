Fundamental types:
	Integer -> short, long, long long, int
	Real numbers -> float, double
	Character -> char, unsigned char
	Boolean -> bool

Auto variable
	Compiler declares the type
	The variable is still strongly typed
	Useful for UGLY declaration

Declaration
	Declare a variable as late as possible
	Best not to declare until you can initialize
		- Fundamental types are not default-initialized
		- Wait until you have the value to put in them

Input/output
	std::cin >> answer;
	std::cout << "string" << variable << e.g. '\n';

Casting
	Putting variables of one type to variables of differet type:
		// i2 is int:
			static_cast<double>(i1)/ i2;
		// d1 is double
			static_case<int>(d1);
const
	Only when declaring a variable to avoid changing the value of a variable:
		int const amount = 90;