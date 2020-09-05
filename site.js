fetch('https://api.github.com/gists/44ddba9c6b1d9e5db33dd89e60ba879b')
    .then(results => {
        return results.json();
    })
    .then(data => {
        info = JSON.parse(data.files["pbinfo.json"].content);
        console.log(info);

        renderPlayersTable();

        renderGroups();
    });

function renderPlayersTable() {
    var playersTableString = "";
    info.players.forEach(p => {
        playersTableString += `<tr><td>${p.name}</td>
                            <td>${p.teamName}</td>
                            <td>${p.teamMembers}</td>
                            <tr>`
    });
    document.querySelector("#playersTable").innerHTML = playersTableString;
}

function renderGroups() {

    info.groups.forEach(g => {
        var groupHTML = "";
        groupHTML += `<div class="groupPlayCard">
        <div class="groupPlayHeader">
            Group ${g.group}
        </div>
        <div class="groupPlayBody">
            <table>`;
        g.members.forEach(m => {
            var person = info.players.find(e => e.pid == m);
            groupHTML += `<tr>
                <td>${person.pid}</td>
                <td>${person.teamName}</td>
                <td>${calculateMatches(person.pid)}</td>
            </tr>`
        });

        groupHTML += `</table></div>`;

        groupHTML += renderMatches(g.group);

        document.querySelector("#groupPlayBox").innerHTML += groupHTML;
    });
}

function renderMatches(groupId) {
    matchString = `<div class="groupPlayHeader">
                        Matches
                    </div>
                    <div class="groupPlayBody">
                        <table>`;
    let group = info.groups.find(g => g.group == groupId);
    group.matches.forEach(m => {
        matchString += `<tr><td>${info.players.find(p => p.pid == m.p1).teamName}</td>`
        if (m.w === null) {
            matchString += `<td></td><td></td>`;
        } else if (m.w === m.p1) {
            matchString += `<td>W</td><td>L</td>`;
        }
        else if (m.w === m.p2) {
            matchString += `<td>L</td><td>W</td>`;
        }
        matchString += `<td>${info.players.find(p => p.pid == m.p2).teamName}</td></tr>`
    });

    return matchString;
}

function calculateMatches(playerId) {
    let player = info.players.find(p => p.pid == playerId);
    let playerWin = 0;
    let playerLoss = 0;
    info.groups.find(g => g.members.includes(playerId)).matches.forEach(m => {
        if ((m.p1 == playerId || m.p2 == playerId) && m.w !== null) {
            if (m.w == playerId) {
                playerWin++;
            }
            else {
                playerLoss++;
            }
        }
    });
    return `${playerWin}-${playerLoss}`;
}