namespace Odata.Contract.Dtos;

public record AreaDto(int Id,string Title,bool IsActive,int Code);
public record AreaSave(string Title, bool IsActive, int Code) ;