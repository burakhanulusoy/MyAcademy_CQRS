namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands;

    public record CreateCustomerCommand(
    string NameSurname,
    string City,
    string PhoneNumber);
 

