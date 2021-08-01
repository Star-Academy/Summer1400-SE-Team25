package modelTest.queryTest;

import model.DocumentFile;
import model.InvertedIndex;
import model.query.OROperator;
import model.query.Operator;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;
import util.WordUtil;

import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class OROperatorTest {
    private final String QUERY_STRING = "friend";
    private Set<DocumentFile> previewSearchResult;
    private Operator orOperator;
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
        orOperator = new OROperator(QUERY_STRING, invertedIndex);
    }

    @Test
    public void testOperateBothAddition() {
        initializePreviewResult();
        previewSearchResult.add(documentFile);
        previewSearchResult.add(additionalDocumentFile);
        var result = orOperator.operate(previewSearchResult, wordUtil);
        assertTrue(result.contains(documentFile));
        assertTrue(result.contains(additionalDocumentFile));
    }

    @Test
    public void testOperateUnion() {
        initializePreviewResult();
        previewSearchResult.add(additionalDocumentFile);
        var result = orOperator.operate(previewSearchResult, wordUtil);
        assertTrue(result.contains(documentFile));
        assertTrue(result.contains(additionalDocumentFile));
    }

    @Test
    public void testOneAddition() {
        initializePreviewResult();
        previewSearchResult.add(documentFile);
        var result = orOperator.operate(previewSearchResult, wordUtil);
        assertTrue(result.contains(documentFile));
        assertFalse(result.contains(additionalDocumentFile));
    }
}
