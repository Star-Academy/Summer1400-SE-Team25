import controller.FileHandler;
import controller.QueryHandler;
import model.FileMapper;
import model.InvertedIndex;
import view.SearchEngine;

public class Main {
    public static void main(String[] args) {
        InvertedIndex invertedIndex = new InvertedIndex();
        FileMapper fileMapper = new FileMapper(invertedIndex);
        FileHandler fileHandler = new FileHandler(fileMapper);
        fileHandler.initialize();
        QueryHandler queryHandler = new QueryHandler(invertedIndex);
        SearchEngine searchEngine = new SearchEngine(queryHandler);
        searchEngine.start();
    }
}