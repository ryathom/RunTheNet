using System.Collections;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface ICost
    {
        public abstract IEnumerator Pay();
        public abstract bool CanPay();

        public abstract ICost Copy();
    }
}