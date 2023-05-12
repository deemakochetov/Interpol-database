using CriminalsProgram.Models.Helpers;

namespace CriminalsProgram.Models.Main
{
  public class CriminalBuilder
  {
    private readonly Criminal _criminal;

    public CriminalBuilder()
    {
      _criminal = new Criminal();
    }

    public CriminalBuilder WithId(int id)
    {
      _criminal.Id = id;
      return this;
    }

    public CriminalBuilder WithFirstName(string firstName)
    {
      _criminal.FirstName = firstName;
      return this;
    }

    public CriminalBuilder WithLastName(string lastName)
    {
      _criminal.LastName = lastName;
      return this;
    }

    public CriminalBuilder WithNickname(string nickname)
    {
      _criminal.Nickname = nickname;
      return this;
    }

    public CriminalBuilder WithHeight(int height)
    {
      _criminal.Height = height;
      return this;
    }

    public CriminalBuilder WithWeight(int weight)
    {
      _criminal.Weight = weight;
      return this;
    }

    public CriminalBuilder WithHairColor(string hairColor)
    {
      _criminal.HairColor = hairColor;
      return this;
    }

    public CriminalBuilder WithEyesColor(string eyesColor)
    {
      _criminal.EyesColor = eyesColor;
      return this;
    }

    public CriminalBuilder WithNationality(string nationality)
    {
      _criminal.Nationality = nationality;
      return this;
    }

    public CriminalBuilder WithBirthPlace(string birthPlace)
    {
      _criminal.BirthPlace = birthPlace;
      return this;
    }

    public CriminalBuilder WithLastResidencePlace(string lastResidencePlace)
    {
      _criminal.LastResidencePlace = lastResidencePlace;
      return this;
    }

    public CriminalBuilder WithCurrentLocation(string currentLocation)
    {
      _criminal.CurrentLocation = currentLocation;
      return this;
    }

    public CriminalBuilder WithLanguages(string languages)
    {
      _criminal.Languages = languages;
      return this;
    }

    public CriminalBuilder WithCriminalJob(string criminalJob)
    {
      _criminal.CriminalJob = criminalJob;
      return this;
    }

    public CriminalBuilder WithLastCase(string lastCase)
    {
      _criminal.LastCase = lastCase;
      return this;
    }

    public CriminalBuilder WithAliases(List<Alias> aliases)
    {
      _criminal.Aliases = aliases;
      return this;
    }

    public CriminalBuilder WithAppearance(string appearance)
    {
      _criminal.Appearance = appearance;
      return this;
    }

    public CriminalBuilder WithGender(Gender gender)
    {
      _criminal.Gender = gender;
      return this;
    }

    public CriminalBuilder WithDescription(string description)
    {
      _criminal.Description = description;
      return this;
    }

    public CriminalBuilder WithStatus(CriminalStatus status)
    {
      _criminal.Status = status;
      return this;
    }

    public CriminalBuilder WithDateOfBirth(DateOnly dateOfBirth)
    {
      _criminal.DateOfBirth = dateOfBirth;
      return this;
    }

    public Criminal Build()
    {
      return _criminal;
    }
  }
}
