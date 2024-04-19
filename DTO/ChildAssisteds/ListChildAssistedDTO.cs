namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class ListChildAssistedDTO
    {
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public List<ChildAssistedDTO> ChildAssisteds { get; set; } = new List<ChildAssistedDTO>();

        public ListChildAssistedDTO()
        {

        }
        public ListChildAssistedDTO(List<ChildAssistedDTO> childAssisteds, int totalPages, int pageNumber)
        {
            ChildAssisteds = childAssisteds;
            TotalPages = totalPages;    
            PageNumber = pageNumber;    
        }
    }
}
