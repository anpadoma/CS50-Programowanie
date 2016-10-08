using System.Collections.Generic;

namespace Chapter05
{
    public class UserCache
    {
        private Dictionary<string, UserInfo> _cachedUserInfo = new Dictionary<string, UserInfo>();

        public UserInfo GetInfo(string userHandle )
        {
            RemoveStaleCacheEntries();
            UserInfo info;
            if (!_cachedUserInfo.TryGetValue(userHandle, out info))
            {
                info = FetchUserInfo(userHandle);
                _cachedUserInfo.Add(userHandle, info);
            }
            return info;
        }

        private UserInfo FetchUserInfo(string userHandle)
        {
            //pobranie danych użytkownika
            throw new System.NotImplementedException();
        }

        private void RemoveStaleCacheEntries()
        {
            //używana w tej aplikacji logika usuwania niepotrzebnych danych
            throw new System.NotImplementedException();
        }
    }

    public class UserInfo
    {
        //informacja o użytkowniku
    }
}
