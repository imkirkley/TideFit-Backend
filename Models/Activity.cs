namespace api.Models
{
    public class Activity
    {
        public string ExerciseId {get; set;}
        public string ActivityType {get; set;}
        public string Distance {get; set;}
        public string DateCompleted {get; set;}
        public bool Pin {get; set;}
        public bool Deleted {get; set;}
        
        public Activity() {
            ExerciseId = Guid.NewGuid().ToString();
        }


        public override string ToString() {
            return $"{ActivityType} {Distance} {DateCompleted} {Pin}";
        }
    }
}