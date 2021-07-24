import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;

public class WordUtil {
    private static ArrayList<String> stopWords = new ArrayList<>();

    public static String extractRootWord(String word){
        word = word.toLowerCase();
        word = removeSymbols(word);
        if (isStopWord(word))
            return null;
        return word;
    }

    private static String removeSymbols(String word) {
        word = word.replace('+', ' ');
        word = word.replace('?', ' ');
        word = word.replace('.', ' ');
        word = word.replace("-", "");
        word = word.replace("\"", "");
        word = word.replace("'", "");
        word = word.replace(">", "");
        word = word.replace("<", "");
        word = word.replace("/", "");
        word = word.replace(",", "");
        word = word.replace("|", "");
        word = word.replace(" ", "");
        return word;
    }

    private static boolean isStopWord(String word) {
        if (stopWords.size() == 0)
            initStopWords();
        return stopWords.contains(word);
    }

    private static void initStopWords() {
        try (Scanner fileScanner = new Scanner(new File("StopWords.txt"))) {
            while (fileScanner.hasNext())
                stopWords.add(fileScanner.nextLine());
        }
        catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
