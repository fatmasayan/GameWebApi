namespace GameWebApi2.Mapping;

public class UserInventoryProfile : Profile
{
    public UserInventoryProfile()
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<UserInventory, UserProfileViewModel>();

        CreateMap<UserInventoryDTO, UserInventory>();

        CreateMap<UserInventoryAddDTO, UserInventory>();

        CreateMap<UserInventoryUpdateDTO, UserInventory>();

    }
}
