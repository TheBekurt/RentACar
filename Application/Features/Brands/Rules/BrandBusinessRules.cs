using Application.Services.Repositories;
using Application.Features.Brands.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }   


    public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
    {
        var existingBrand = await _brandRepository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());
        if (existingBrand != null)
        {
            throw new BusinessException(BrandMessages.BrandNameAlreadyExists);
        }
    }
}
