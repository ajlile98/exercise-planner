#!/bin/bash

# Interactive commit helper with conventional commits

echo "🔹 Select commit type:"
select type in "feat (new feature)" "fix (bug fix)" "docs (documentation)" "style (formatting)" "refactor (code restructure)" "perf (performance)" "test (tests)" "chore (maintenance)"; do
    case $type in
        "feat (new feature)") TYPE="feat"; break;;
        "fix (bug fix)") TYPE="fix"; break;;
        "docs (documentation)") TYPE="docs"; break;;
        "style (formatting)") TYPE="style"; break;;
        "refactor (code restructure)") TYPE="refactor"; break;;
        "perf (performance)") TYPE="perf"; break;;
        "test (tests)") TYPE="test"; break;;
        "chore (maintenance)") TYPE="chore"; break;;
    esac
done

echo ""
echo "🔹 Enter scope (optional, press Enter to skip):"
read SCOPE

echo ""
echo "🔹 Enter commit message (required):"
read MESSAGE

# Build commit message
if [ -z "$SCOPE" ]; then
    COMMIT_MSG="$TYPE: $MESSAGE"
else
    COMMIT_MSG="$TYPE($SCOPE): $MESSAGE"
fi

echo ""
echo "📝 Commit message:"
echo "$COMMIT_MSG"
echo ""

# Ask for confirmation
read -p "Commit? (y/n) " -n 1 -r
echo
if [[ $REPLY =~ ^[Yy]$ ]]; then
    git commit -m "$COMMIT_MSG"
else
    echo "Cancelled"
fi
