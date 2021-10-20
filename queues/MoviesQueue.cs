using System;

/*
    The Movies available for hiring are stored here. However, these are only
      in which a store starts with as new bikes can be added or removed
       in the system.
*/  
public class MoviesQueue : GenericQueue<Movie>
    {
        public MoviesQueue() : base() { }

        public override string ToString()
        {
            string returnString = "";

            foreach (Movie movie in this)
            {
                //Node<Bike> previous = this.Current.Previous;
                Node<Movie> next = this.Current.Next;

                string previousName = "null";
                string nextName  = "null";

                //if(previous is not null)
                //    if (previous.Content.Description is not null)
                //        previousName = previous.Content.Description;

                if(next is not null)
                    if (next.Content.Description is not null)
                        nextName = next.Content.Description;

                returnString += previousName + " - " + movie.ToString().PadRight(15) + " - " + nextName + "\n";

            }
          
            return returnString;
        }

        public void Add(Movie movie) {

            /*int code = 0;

            if (this.Length > 0) {

                foreach (Movie m in this)
                {
                    if (code < m.Code || code == 0)
                        code = m.Code;
                }

            }

            movie.Code = ++code;

            base.Add(movie);*/
        }

        public Movie FindByCode(Movie obj)
        {
            /*foreach (Movie movie in this)
            {
                if (movie.Code.Equals(obj.Code))
                    return movie;
            }*/
            return null;
        }

        public override Movie GetHeadElement()
        {
            return base.GetHeadElement();
        }

    }