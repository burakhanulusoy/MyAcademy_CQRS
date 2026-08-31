namespace MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults;

public record GetCustomerByIdQueryResult(int Id,
    string NameSurname,
    string City,
    string PhoneNumber
);

