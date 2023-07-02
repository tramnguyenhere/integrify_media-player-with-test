namespace MediaPlayerWithTest.src.Domain.Core
{
    public class User : BaseEntity
    {
        public List<PlayList> Lists;

        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
            Lists = new();
        }

        public void AddNewList(string name, int userId)
        {
            var newList = new PlayList(name, userId);
            Lists.Add(newList);
        }

        public void RemoveOneList(PlayList list)
        {
            Lists.Remove(list);
        }

        public void EmptyOneList(PlayList list)
        {
            if (Lists.Contains(list))
                list.EmptyList(GetId);
            else
                throw new ArgumentNullException(nameof(list), "Playlist is not found");
        }

        public override string ToString()
        {
            return $"Id: {GetId}, Name: {Name}, Number of playlists: {Lists.Count}";
        }
    }
}
