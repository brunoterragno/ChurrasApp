export function getStateWithFieldErrors(
  actualState,
  propWithField,
  fieldsWithErrors
) {
  return fieldsWithErrors.reduce((prevState, error) => {
    // normalize prop name
    const field = error.field.toLowerCase();
    // set with Immutable
    return prevState.setIn([propWithField, `${field}`], {
      [field]: '',
      error: error.message
    });
  }, actualState);
}

export function getInsertObject(obj) {
  // get all object values
  const result = Object.keys(obj).map(p => {
    return { [p]: obj[p].value };
  });
  // normalize to an object (not array)
  const normalized = result.reduce((p, c) => ({ ...p, ...c }), {});
  delete normalized.loading;
  return normalized;
}
