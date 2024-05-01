namespace Education.DtoLayer.Dtos.CafeteriaCardDto
{
    public class CardTransactionResult
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public int NewBalance { get; set; }
    }
}
