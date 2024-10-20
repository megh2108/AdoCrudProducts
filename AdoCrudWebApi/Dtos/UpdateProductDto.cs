namespace AdoCrudWebApi.Dtos
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
