namespace TaskManagement.Dto
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string AssociatedProject { get; set; }

        public string DueDate { get; set; }

    }
}
