namespace FirstExerciseWebMinimalApi.Person;

public interface IPersonService
{
    Person GetById(Guid id);
    List<Person> GetAll();
    void Create(Person person);
   
    
}