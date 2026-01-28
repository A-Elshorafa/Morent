namespace Morent.Core.DTOs;

public class CarListDto
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
  public string? SearchToken { get; set; }
  public DateTime? FromDate { get; set; }
  public DateTime? ToDate { get; set; }
  public int? LocationId { get; set; }

  public CarListDto(
    int pageNumber = 1,
    int pageSize = 10,
    string? searchToken = "",
    DateTime? fromDate = null,
    DateTime? toDate = null,
    int? locationId = null
  ) {
    ToDate = toDate;
    PageSize = pageSize;
    FromDate = fromDate;
    PageNumber = pageNumber;
    LocationId = locationId;
    SearchToken = searchToken;
  }
}
