namespace MyAcademyCqrsDesignPattern.CqrsPattern.Commands.TestimonialCommands;

    public record CreateTestimonialCommand(int Id,
                                           string ImageUrl,
                                           string FullName,
                                           string Comment,
                                           string Title);

