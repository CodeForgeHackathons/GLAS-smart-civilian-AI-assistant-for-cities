using System;

namespace GLAS_Server.Models
{
    public class NotificationSettings
    {
        public uint Id { get; set; }
        public uint AccountID { get; set; }
        public bool AchievementsEnabled { get; set; } = true;
        public bool GeneralEnabled { get; set; } = true;
        public bool SoundEnabled { get; set; } = true;
        public bool VibrationEnabled { get; set; } = true;
        public TimeSpan NotificationTime { get; set; } = new TimeSpan(9, 0, 0);


    }
}
