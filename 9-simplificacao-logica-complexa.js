function processList(items) {
  let processed = [];
  for (let i = 0; i < items.length; i++) {
    if (items[i].active && items[i].status === "pending") {
      if (items[i].amount > 100) {
        processed.push(items[i]);
      }
    }
  }
  return processed;
}
