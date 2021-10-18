using System;

/*
    The bikes available for hiring are stored here. However, these are only
      in which a store starts with as new bikes can be added or removed
       in the system.
*/
public class AvailableBikesQueue : GenericQueue<Bike>
    {
        public AvailableBikesQueue() : base() { }

        public override string ToString()
        {
            string returnString = "";

            foreach (Bike bike in this)
            {
                Node<Bike> previous = this.Current.previous;
                Node<Bike> next = this.Current.next;

                string previousName = "null";
                string nextName  = "null";

                if(previous is not null)
                    if (previous.NodeObject.Description is not null)
                        previousName = previous.NodeObject.Description;

                if(next is not null)
                    if (next.NodeObject.Description is not null)
                        nextName = next.NodeObject.Description;

                returnString += previousName + " - " + bike.ToString().PadRight(15) + " - " + nextName + "\n";

            }
          
            return returnString;
        }

        public void Add(Bike bike) {

            int code = 0;

            if (this.Length > 0) {

                foreach (Bike b in this)
                {
                    if (code < b.Code || code == 0)
                        code = b.Code;
                }

            }

            bike.Code = ++code;

            base.Add(bike);
        }

        public Bike FindByCode(Bike obj)
        {
            foreach (Bike bike in this)
            {
                if (bike.Code.Equals(obj.Code))
                    return bike;
            }
            return null;
        }

        public override Bike GetHeadElement()
        {
            return base.GetHeadElement();
        }

    }