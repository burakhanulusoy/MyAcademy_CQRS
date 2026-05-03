namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.TestimonialCommands;

    public record UpdateTestimonialCommand(int Id,
                                           string ImageUrl,
                                           string FullName,
                                           string Comment,
                                           string Title);
