namespace RLZZ.Timesheet.Client.Model;

public record ClientDto
{
    public string ClientUniqueId { get; set; }
    public string Name { get; set; }

    public ClientDto()
    {
        
    }

    public ClientDto(string clientUniqueId, string name) : this()
    {
        this.ClientUniqueId = clientUniqueId;
        this.Name = name;
    }
}