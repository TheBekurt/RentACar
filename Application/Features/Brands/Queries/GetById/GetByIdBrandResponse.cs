namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}
    public DateTime DeletedDate { get; set; }
  
}