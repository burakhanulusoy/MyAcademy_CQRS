namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands;

public record UpdateCustomerCommand(int Id,
string NameSurname,
string City,
string PhoneNumber);


