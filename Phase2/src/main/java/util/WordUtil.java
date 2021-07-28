package util;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import org.tartarus.snowball.ext.PorterStemmer;

public class WordUtil {
    private final static List<String> stopWords = new ArrayList<>();
    private final static String STOP_WORDS_PATH = "src/main/java/StopWords.txt";

    public static String extractRootWord(String word){
        PorterStemmer stemmer = new PorterStemmer();
        stemmer.setCurrent(word);
        stemmer.stem();
        word = stemmer.getCurrent();
        if (isStopWord(word))
            return null;
        return word;
    }

    private static boolean isStopWord(String word) {
        if (stopWords.size() == 0)
            initStopWords();
        return stopWords.contains(word);
    }

    private static void initStopWords() {
        try (Scanner fileScanner = new Scanner(new File(STOP_WORDS_PATH))) {
            while (fileScanner.hasNext())
                stopWords.add(fileScanner.nextLine());
        }
        catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
