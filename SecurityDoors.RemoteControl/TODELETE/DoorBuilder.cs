using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.RemoteControl.Builders
{
    // TODO: ЗАЧЕМ ВООБЩЕ ЭТО? Кандидат на удаление.

    class DoorBuilder
    {
        private Door door;
        public DoorBuilder()
        {
            door = new Door();
        }

        public Door build()
        {
            return door;
        }

        public DoorBuilder setName(string name)
        {
            door.Name = name;
            return this;
        }

        public DoorBuilder setDescription(string description)
        {
            door.Description = description;
            return this;
        }
    }
}
