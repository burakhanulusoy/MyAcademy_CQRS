namespace MyAcademyCqrsDesignPattern.CqrsPattern.Results.CustomerResults;

    public record GetCustomersQueryResult(int Id,
        string NameSurname,
        string City,
        string PhoneNumber
    );
  
