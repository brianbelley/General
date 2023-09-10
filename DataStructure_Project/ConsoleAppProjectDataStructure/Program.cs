using System;
using System.Collections;
using System.Text.Json;

//Class
public class News
{
    private int id;
    private long time;
    private string content;
    private string[] keywords;
    private int hits;

    public int ID { get => id; set => id = value; }
    public long Time { get => time; set => time = value; }
    public string Content { get => content; set => content = value; }
    public string[] Keywords { get => keywords; set => keywords = value; }
    public int Hits { get => hits; set => hits = value; }

}

// LRU
public class LRUCache
{
    private int capacity;
    private Dictionary<int, Node> cache;
    private Node head;
    private Node tail;

    private class Node
    {
        public int key;
        public News news;
        public Node prev;
        public Node next;

        public Node(int key, News news)
        {
            this.key = key;
            this.news = news;
            this.prev = null;
            this.next = null;
        }
    }

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.cache = new Dictionary<int, Node>();
        this.head = null;
        this.tail = null;
    }

    public void Put(News news)
    {
        if (cache.ContainsKey(news.ID))
        {
            Node node = cache[news.ID];
            node.news = news;
            RemoveNode(node);
            AddToHead(node);
        }
        else
        {
            Node newNode = new Node(news.ID, news);
            if (cache.Count >= capacity)
            {
                cache.Remove(tail.key);
                RemoveNode(tail);
            }
            cache.Add(news.ID, newNode);
            AddToHead(newNode);
        }
    }

    public News Get(int id)
    {
        if (cache.TryGetValue(id, out Node node))
        {
            RemoveNode(node);
            AddToHead(node);
            return node.news;
        }
        return null;
    }

    private void RemoveNode(Node node)
    {
        if (node.prev != null)
        {
            node.prev.next = node.next;
        }
        else
        {
            head = node.next;
        }
        if (node.next != null)
        {
            node.next.prev = node.prev;
        }
        else
        {
            tail = node.prev;
        }
    }

    private void AddToHead(Node node)
    {
        node.prev = null;
        node.next = head;
        if (head != null)
        {
            head.prev = node;
        }
        head = node;
        if (tail == null)
        {
            tail = head;
        }
    }
}




//Trending News
public class TrendingNewsPriorityQueue
{
    private Node head;
    private int count;

    private class Node
    {
        public News news;
        public Node next;

        public Node(News news)
        {
            this.news = news;
            this.next = null;
        }

    }

    public void Enqueue(News news)
    {
        Node newNode = new Node(news);
        if (head == null || news.Hits > head.news.Hits)
        {
            newNode.next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.next != null && news.Hits <= current.next.news.Hits)
            {
                current = current.next;
            }
            newNode.next = current.next;
            current.next = newNode;
        }
        count++;
    }

    public News Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("The queue is empty");
        }
        News news = head.news;
        head = head.next;
        count--;
        return news;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public int Count()
    {
        return count;
    }

    public void PrintFilters(string keyword = null, long? time = null)
    {
        Node current = head;
        while (current != null)
        {
            if ((keyword == null || current.news.Keywords.Contains(keyword)) &&
                (time == null || current.news.Time == time))
            {
                Console.WriteLine("ID: " + current.news.ID + "\nTime: " + current.news.Time + "\nKeywords: " + String.Join(", ", current.news.Keywords) + "\nContent: "
                    + current.news.Content + "\nHits: " + current.news.Hits);
            }
            current = current.next;
        }
    }

}

//Recent

public class RecentNewsLinkedList
{
    private Node head;
    private int count;

    private class Node
    {
        public News news;
        public Node next;

        public Node(News news)
        {
            this.news = news;
            this.next = null;
        }
    }

    public RecentNewsLinkedList()
    {
        this.head = null;
        this.count = 0;
    }

    public void Add(News news)
    {
        NewsOutlet info = new NewsOutlet();
        Node newNode = new Node(news);
        DateTime dateTime = NewsOutlet.UnixTimeToUtc(news.Time);
        DateTime dateFakeTime = NewsOutlet.UnixTimeToUtc(info.FakeTime);
        if (head == null || (dateFakeTime - dateTime).TotalHours <= 24)
        {
            newNode.next = head;
            head = newNode;
            count++;
        }
        else
        {
            Node current = head;
            while (current.next != null && NewsOutlet.UnixTimeToUtc(current.next.news.Time) > dateTime.AddHours(-24))
            {
                current = current.next;
            }
            newNode.next = current.next;
            current.next = newNode;
            count++;
        }
    }

    public void PrintFilters(string keyword = null, long? time = null)
    {
        Node current = head;
        while (current != null)
        {
            if ((keyword == null || current.news.Keywords.Contains(keyword)) &&
                (time == null || current.news.Time == time))
            {
                Console.WriteLine("ID: " + current.news.ID + "\nTime: " + current.news.Time + "\nKeywords: " + String.Join(", ", current.news.Keywords) + "\nContent: "
                    + current.news.Content + "\nHits: " + current.news.Hits);
            }
            current = current.next;
        }
    }

    public int Count()
    {
        return count;
    }
}


//Back
public class BackStack
{
    private Node top;

    private class Node
    {
        public News news;
        public Node next;

        public Node(News news)
        {
            this.news = news;
            this.next = null;
        }
    }

    public void Push(News news)
    {
        Node newNode = new Node(news);
        newNode.next = top;
        top = newNode;
    }

    public News Pop()
    {
        if (top == null)
        {
            throw new InvalidOperationException("The stack is empty");
        }
        News news = top.news;
        top = top.next;
        return news;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public int Count()
    {
        int count = 0;
        Node current = top;
        while (current != null)
        {
            count++;
            current = current.next;
        }
        return count;
    }

    public News Peek()
    {
        if (top == null)
        {
            throw new InvalidOperationException("The stack is empty");
        }
        return top.news;
    }
    
    public void PrintStack()
    {
        Node current = top;
        while (current != null)
        {
            Console.WriteLine("ID: " + current.news.ID + "\nTime: " + current.news.Time + "\nKeywords: " + String.Join(", ", current.news.Keywords) + "\nContent: "
                + current.news.Content + "\nHits: " + current.news.Hits);
            current = current.next;
        }
    }


}


// Construct every data structures into the NewsOutlet Class With maximum number of news and a fake time
public class NewsOutlet
{
    private const int MAX_RECENT_NEWS = 500;
    private const int MAX_TRENDING_NEWS = 500;

    private BackStack backStack;
    private RecentNewsLinkedList recentNews;
    private TrendingNewsPriorityQueue trendingNews;
    private LRUCache newsCache;
    private long fakeTime;

    public long FakeTime { get => fakeTime; set => fakeTime = value; }

    public NewsOutlet()
    {
        backStack = new BackStack();
        recentNews = new RecentNewsLinkedList();
        trendingNews = new TrendingNewsPriorityQueue();
        newsCache = new LRUCache(500);
        fakeTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public void PublishNewsFromFile(string fileName)
    {
        using (StreamReader file = File.OpenText(fileName))
        {
            using (JsonDocument document = JsonDocument.Parse(file.ReadToEnd()))
            {
                JsonElement root = document.RootElement;
                foreach (JsonElement newsElement in root.EnumerateArray())
                {
                    int id = newsElement.GetProperty("ID").GetInt32();
                    long time = long.Parse(newsElement.GetProperty("Time").ToString());
                    string content = newsElement.GetProperty("Content").GetString();
                    int hits = newsElement.GetProperty("Hits").GetInt32();

                    // Get the keywords as an array of strings
                    JsonElement keywordsElement = newsElement.GetProperty("Keywords");
                    string[] keywords = new string[keywordsElement.GetArrayLength()];
                    for (int i = 0; i < keywords.Length; i++)
                    {
                        keywords[i] = keywordsElement[i].GetString();
                    }

                    // Create the news object
                    News news = new News
                    {
                        ID = id,
                        Time = time,
                        Content = content,
                        Keywords = keywords,
                        Hits = hits
                    };

                    // Add the news object to the trending news priority queue
                    int storage = trendingNews.Count();
                    trendingNews.Enqueue(news);
                    if (storage > MAX_TRENDING_NEWS)
                    {
                        trendingNews.Dequeue();
                    }

                    //Add the news object to the recent news linkedlist
                    int tempstorage = recentNews.Count();
                    if(tempstorage <= MAX_RECENT_NEWS)
                    {
                        recentNews.Add(news);
                    }

                    // Put the news object in the news cache
                    newsCache.Put(news);
                }
            }
        }
    }

    public News GetNewsById(int id)
    {
        News news = newsCache.Get(id);

        Console.WriteLine("ID: " + news.ID + "\nTime: " + news.Time + "\nKeywords: " + String.Join(", ", news.Keywords) + "\nContent: "
                + news.Content + "\nHits: " + news.Hits);
        news.Hits++;

        if (news != null)
        {
            backStack.Push(news);
            newsCache.Put(news);
            return news;
        }
        return null;
    }

    public void PrintRecentNews()
    {
        Console.WriteLine("\nRecent News: \n");
        int storage = recentNews.Count();
        if( storage <= MAX_RECENT_NEWS)
        {
            Console.WriteLine("\nDo you want to apply any filters ?Y/N");

            char choice = char.Parse(Console.ReadLine());

            if (choice == 'Y')
            {
                var filter = Console.ReadLine();


                while (filter != null)
                {
                    recentNews.PrintFilters(filter);
                    break;
                }
            }
            else if (choice == 'N')
            {
                recentNews.PrintFilters();
            }
        }
    }

    public void PrintTrendingNews()
    {
        int storage = trendingNews.Count();
        Console.WriteLine("\nTrending News: \n");
        if (storage <= MAX_TRENDING_NEWS)
        {
            Console.WriteLine("\nDo you want to apply any filters ?Y/N");
            
            char choice = char.Parse(Console.ReadLine());

            if (choice == 'Y')
            {
                var filter = Console.ReadLine();


                while (filter != null)
                {
                    trendingNews.PrintFilters(filter);
                    break;
                }
            }else if(choice == 'N')
            {
                trendingNews.PrintFilters();
            }
        }
    }

    public void PrintOldNews()
    {
        Console.WriteLine("\nPreviously Selected: \n");
        backStack.PrintStack();
    }

    public static DateTime UnixTimeToUtc(long unixTimeSeconds)
    {
        // Unix time is measured in seconds from January 1, 1970 UTC
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Add the number of seconds to the Unix epoch to get the UTC time
        return unixEpoch.AddSeconds(unixTimeSeconds);
    }

    public void setTime(long time)
    {

    }
}



public class Run
{
    public static void Main(String[] args)
    {

        NewsOutlet news = new NewsOutlet();
        news.PublishNewsFromFile("E:\\Brian\\backup\\Important\\Lasalle College\\Classes\\Semester 4\\DataStructure\\ConsoleAppProjectDataStructure\\ConsoleAppProjectDataStructure\\MOCK_DATA.json");

        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. SHOW");
            Console.WriteLine("2. SELECT");
            Console.WriteLine("3. BACK");
            Console.WriteLine("4. SET");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Perform action for SHOW
                    Console.WriteLine("\n Choose between recent or trending: ");
                    string result = Console.ReadLine();

                    switch (result)
                    {
                        case "recent":
                            news.PrintRecentNews();
                            break;
                        case "trending":
                            news.PrintTrendingNews();
                            break;
                        default:
                            Console.WriteLine("Try Again");
                            Console.WriteLine(result);
                            break;
                    }

                    break;
                case 2:
                    // Perform action for SELECT

                    Console.WriteLine("\nInsert the ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    news.GetNewsById(id);
                    break;
                case 3:
                    Console.WriteLine("You chose BACK.");
                    // Perform action for BACK
                    news.PrintOldNews();
                    break;
                case 4:
                    Console.WriteLine("You chose SET.");
                    // Perform action for SET
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}