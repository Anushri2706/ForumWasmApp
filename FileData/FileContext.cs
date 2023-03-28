using System.Text.Json;
using Domain.Model;

namespace FileData;

public class FileContext
{
    //File path-
    private const string filePath = "data.json";
    //Will contain all the data
    private DataContainer? dataContainer;

    public ICollection<Post> Posts
    {
        get
        {
            LazyLoadData();
            return dataContainer!.Posts;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LazyLoadData();
            return dataContainer!.Users;
        }
    }

    private void LazyLoadData()
    {
        if (dataContainer == null)
        {
            LoadData();
        }
    }
//check if there is a file, and if not, we just create a new "empty" DataContainer.
    //  If there is a file: We read all the content of the file, it returns a string.
    // Then that string is deserialized into a DataContainer, and assigned to the field variable.
    private void LoadData()
    {
        if (dataContainer != null) return;
        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                Posts = new List<Post>(),
                Users = new List<User>()
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    //Puts DataContainer content in a file
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });    
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}