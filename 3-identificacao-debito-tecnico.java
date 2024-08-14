public class UserManager {
    private List<User> users;
    
    public UserManager() {
        users = new ArrayList<>();
    }

    public void addUser(String name, int age) {
        User user = new User();
        user.name = name;
        user.age = age;
        users.add(user);
    }

    public void removeUser(String name) {
        for (int i = 0; i < users.size(); i++) {
            if (users.get(i).name.equals(name)) {
                users.remove(i);
                break;
            }
        }
    }
    
    public List<String> getUserNames() {
        List<String> names = new ArrayList<>();
        for (User user : users) {
            names.add(user.name);
        }
        return names;
    }
}
