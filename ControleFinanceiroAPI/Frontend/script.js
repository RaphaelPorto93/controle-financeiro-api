const API_URL = "http://localhost:5155";


async function carregarCategorias() {
  const resposta = await fetch(`${API_URL}/categorias`);
  const categorias = await resposta.json();

  const lista = document.getElementById("lista-categorias");
  lista.innerHTML = "";

  categorias.forEach(cat => {
    const item = document.createElement("li");
    item.textContent = `#${cat.id} - ${cat.nome}`;
    lista.appendChild(item);
  });
}

document.getElementById("form-categoria").addEventListener("submit", async (e) => {
  e.preventDefault();

  const nome = document.getElementById("input-categoria").value;

  await fetch(`${API_URL}/categorias`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ nome })
  });

  document.getElementById("form-categoria").reset();
  carregarCategorias();
});

carregarCategorias();


async function carregarTransacoes() {
  const resposta = await fetch(`${API_URL}/transacoes`);
  const transacoes = await resposta.json();

  const lista = document.getElementById("lista-transacoes");
  lista.innerHTML = "";

  transacoes.forEach(tx => {
    const item = document.createElement("li");
    item.textContent = `#${tx.id} - ${tx.descricao} | R$ ${tx.valor.toFixed(2)} | Categoria ${tx.categoriaId}`;
    lista.appendChild(item);
  });
}

document.getElementById("form-transacao").addEventListener("submit", async (e) => {
  e.preventDefault();

  const descricao = document.getElementById("descricao").value;
  const valor = parseFloat(document.getElementById("valor").value);
  const categoriaId = parseInt(document.getElementById("categoriaId").value);

  await fetch(`${API_URL}/transacoes`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ descricao, valor, categoriaId })
  });

  document.getElementById("form-transacao").reset();
  carregarTransacoes();
});

carregarTransacoes();
