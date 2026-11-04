using Codefy.Application.Projects.Categories.Dtos;
using Codefy.Application.Projects.Categories.Repositories;
using Codefy.Domain.Entities;

namespace Codefy.Application.Projects.Categories.UseCases.CreateProjectCategory;

public class CreateProjectCategoryUseCase
{
    private readonly IProjectCategoryWriteRepository _categoryRepository;

    public CreateProjectCategoryUseCase(
        IProjectCategoryWriteRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> ExecuteAsync(
        CreateProjectCategoryRequest request,
        CancellationToken cancellationToken = default)
    {
        var name = request.Name.Trim();
        var slug = request.Slug.Trim().ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "O nome da categoria é obrigatório.");

        if (string.IsNullOrWhiteSpace(slug))
            throw new ArgumentException(
                "O slug da categoria é obrigatório.");

        var slugAlreadyExists =
            await _categoryRepository.ExistsBySlugAsync(
                slug,
                cancellationToken);

        if (slugAlreadyExists)
            throw new InvalidOperationException(
                "Já existe uma categoria com esse slug.");

        var category = new ProjectCategory
        {
            Name = name,
            Slug = slug,
            DisplayOrder = request.DisplayOrder
        };

        await _categoryRepository.AddAsync(
            category,
            cancellationToken);

        await _categoryRepository.SaveChangesAsync(
            cancellationToken);

        return category.Id;
    }
}
