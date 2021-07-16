using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WoWs_Randomizer.utils
{
    public abstract class Enumeration : IComparable, IEquatable<Enumeration>
    {
        public string Name { get; private set; }

        public String Abbreviation { get; private set; }

        protected Enumeration(string abbreviation, string name)
        {
            Abbreviation = abbreviation;
            Name = name;
        }

        public override string ToString() => Abbreviation.ToLower();

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Abbreviation.ToLower().Equals(otherValue.Abbreviation.ToLower());

            Console.WriteLine(Abbreviation.ToString());
            Console.WriteLine(otherValue.ToString());

            return ((typeMatches && valueMatches) || Abbreviation.ToString().Equals(otherValue.Abbreviation.ToString()));
        }

        public int CompareTo(object other) => Abbreviation.CompareTo(((Enumeration)other).Abbreviation);

        public bool Equals(Enumeration other)
        {
            if (other == null)
                return false;

            var typeMatches = GetType().Equals(other.GetType());
            var valueMatches = Abbreviation.Equals(other.Abbreviation);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
