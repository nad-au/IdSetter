﻿namespace IdSetter
{
    public class Entity1
    {
        [IdField]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
