package modelTest.queryTest;

import static org.junit.Assert.*;

import model.DocumentFile;
import model.InvertedIndex;
import model.query.ANDOperator;
import model.query.Operator;
import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;
import util.WordUtil;

import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class)
public class ANDOperatorTest {
    private final String QUERY_STRING = "friend";
    private Set<DocumentFile> previewSearchResult;
    private Operator andOperator;
    @Mock
    private InvertedIndex invertedIndex;
    @Mock
    private WordUtil wordUtil;
    @Mock
    private DocumentFile documentFile;
    @Mock
    private DocumentFile additionalDocumentFile;

    @Before
    public void initialize() {
        when(invertedIndex.getOccurredDocuments(anyString())).thenReturn(new HashSet<>(Collections.singletonList(documentFile)));
        when(wordUtil.extractRootWord(anyString())).thenReturn(QUERY_STRING);
    }

    private void initializePreviewResult() {
        previewSearchResult = new HashSet<>();
        previewSearchResult.add(documentFile);
        previewSearchResult.add(additionalDocumentFile);
        andOperator = new ANDOperator(QUERY_STRING, invertedIndex);
    }

    @Test
    public void testOperate() {
        initializePreviewResult();
        var result = andOperator.operate(previewSearchResult, wordUtil);
        assertTrue(result.contains(documentFile));
    }
}
