using Microsoft.EntityFrameworkCore;
using SocialNetworkMVC.Models;

namespace SocialNetworkMVC.DataBase.Repositories
{
    public class FriendRepository: Repository<Friend>
    {
        public FriendRepository(MyAppContext db) : base(db)
        {

        }
        public void AddFriend(User target, User friend)
        {
            if (target.Id == friend.Id)
            {
                return;
            }

            // Проверяем, есть ли уже запись о дружбе в одной из сторон
            var existingFriendship = Set.AsEnumerable().FirstOrDefault(x =>
                (x.UserId == target.Id && x.CurrentFriendId == friend.Id) ||
                (x.UserId == friend.Id && x.CurrentFriendId == target.Id));

            // Если дружбы нет, создаем обе записи
            if (existingFriendship == null)
            {
                // Запись для первого пользователя
                var item1 = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = friend,
                    CurrentFriendId = friend.Id,
                };

                Create(item1);

                // Запись для второго пользователя
                var item2 = new Friend()
                {
                    UserId = friend.Id,
                    User = friend,
                    CurrentFriend = target,
                    CurrentFriendId = target.Id,
                };

                Create(item2);
            }
        }

        public List<User> GetFriendsByUser(User target)
        {
            var friends = Set.Include(x => x.CurrentFriend).Include(x => x.User).AsEnumerable().Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend);

            return friends.ToList();
        }

        public void DeleteFriend(User target, User friend)
        {
            if (target.Id == friend.Id)
            {
                return;
            }

            // Найти обе записи о дружбе
            var friendship1 = Set.FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);
            var friendship2 = Set.FirstOrDefault(x => x.UserId == friend.Id && x.CurrentFriendId == target.Id);

            // Удаляем записи, если они существуют
            if (friendship1 != null)
            {
                Delete(friendship1);
            }
            if (friendship2 != null)
            {
                Delete(friendship2);
            }
        }
    }
}
