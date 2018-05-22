describe('Home', function() {
  it('.should() - assert that title is correct', function() {
    cy.visit('http://localhost:3000');

    cy.title().should('include', 'Churras App!');
  });

  it('.should() - assert that header is correct', function() {
    cy.visit('http://localhost:3000');

    cy.get('h1').should('be', 'Churras App');
  });
});
