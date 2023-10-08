using IBAS_menu.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure.Data.Tables;

public class MenuModel : PageModel
{
    private readonly TableClient _client = new TableClient("DefaultEndpointsProtocol = https; AccountName = ibasmenustorage; AccountKey = mmIt62TqhfJtSqwsFNLyoSkpMk4WQ8AtZUnz64MnWUJZuThd7wXws//oIHVpiOn7q4bDamGjeRg++AStxl0WCQ==;EndpointSuffix=core.windows.net", "menu");

    public List<IbasMenuDTO> MenuItems { get; private set; } = new List<IbasMenuDTO>();
     

    public async Task OnGetAsync()
    {
        // Query Azure Table Storage for entities of type IbasMenuDTO
        var entities = _client.Query<IbasMenuDTO>().ToList();

        // Initialize a list to store menu items
        MenuItems = entities.Select(entity => new IbasMenuDTO
        {
            // Map properties from Azure Table Storage entity to DTO properties
            Weekday = entity.PartitionKey, // Map PartitionKey to Weekday
            ColdDish = entity.ColdDish,     // Map ColdDish property
            WarmDish = entity.WarmDish,     // Map WarmDish property
        }).ToList();
    }


}
