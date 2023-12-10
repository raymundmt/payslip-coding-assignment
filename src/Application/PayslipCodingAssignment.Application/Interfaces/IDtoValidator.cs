namespace PayslipCodingAssignment.Application.Interfaces;
public interface IDtoValidator<TDto>
{
    void Validate(TDto input);
}
