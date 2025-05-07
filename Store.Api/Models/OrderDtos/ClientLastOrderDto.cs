namespace Store.Api.Models.OrderDtos
{
    public class ClientLastOrderDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateLastOrder { get; set; }
    }
}
